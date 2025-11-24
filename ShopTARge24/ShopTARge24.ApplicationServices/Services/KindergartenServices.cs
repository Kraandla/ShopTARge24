using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShopTARge24.Core.Domain;
using ShopTARge24.Core.Dto;
using ShopTARge24.Core.ServiceInterface;
using ShopTARge24.Data;

namespace ShopTARge24.ApplicationServices.Services
{
        public class KindergartenServices : IKindergartenServices
        {
            private readonly ShopTARge24Context _context;
            private readonly IFileServices _fileServices;

        public KindergartenServices
                (
                    ShopTARge24Context context
                    , IFileServices fileServices
                )
            {
                _context = context;
                _fileServices = fileServices;

        }

        public async Task<Kindergarten> Create(KindergartenDto dto)
            {
                Kindergarten domain = new Kindergarten();

                domain.Id = Guid.NewGuid();
                domain.KindergartenName = dto.KindergartenName;
                domain.GroupName = dto.GroupName;
                domain.TeacherName = dto.TeacherName;
                domain.ChildCount = (int)dto.ChildCount;
                domain.CreatedAt = DateTime.Now;
                domain.UpdatedAt = DateTime.Now;


                if (dto.Files != null)
                {
                    _fileServices.UploadFilesToDatabaseKindergarten(dto, domain);
                }
                await _context.Kindergartens.AddAsync(domain);
                await _context.SaveChangesAsync();

                return domain;
            }

            public async Task<Kindergarten> Update(KindergartenDto dto)
            {
                var domain = await _context.Kindergartens.FirstOrDefaultAsync(x => x.Id == dto.Id);
                //vaja leida doamini objekt, mida saaks mappida dto-ga
                if (domain == null)
                    return null;

                domain.KindergartenName = dto.KindergartenName;
                domain.GroupName = dto.GroupName;
                domain.TeacherName = dto.TeacherName;
                domain.ChildCount = (int)dto.ChildCount;
                domain.CreatedAt = (DateTime)dto.CreatedAt;
                domain.UpdatedAt = DateTime.Now;

                if (dto.Files != null)
                {
                    _fileServices.UploadFilesToDatabaseKindergarten(dto, domain);
                }

                await _context.SaveChangesAsync();

                return domain;
            }

            public async Task<Kindergarten> DetailAsync(Guid id)
            {
                var result = await _context.Kindergartens
                    .FirstOrDefaultAsync(x => x.Id == id);

                return result;
            }

            public async Task<Kindergarten> Delete(Guid id)
            {
                //leida ülesse konkreetne soovitud rida, mida soovite kustutada
                var result = await _context.Kindergartens
                    .FirstOrDefaultAsync(x => x.Id == id);


            //kui rida on leitud, siis eemaldage andmebaasist
                _fileServices.DeleteFilesFromDatabaseKindergarten(id);
                _context.Kindergartens.Remove(result);
                await _context.SaveChangesAsync();

                return result;
            }
        }
}
