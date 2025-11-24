using ShopTARge24.Core.Dto;
using ShopTARge24.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARge24.KindergartenTest
{
    public class KindergartenTests : TestBase
    {
        [Fact]
        public async Task Should_CreateKindergarten_WhenValidData()
        {
            KindergartenDto dto = MockKindergartenDto();
            var result = await Svc<IKindergartenServices>().Create(dto);

            Assert.NotNull(result);
            Assert.Equal(dto.KindergartenName, result.KindergartenName);
            Assert.Equal(dto.GroupName, result.GroupName);
            Assert.Equal(dto.TeacherName, result.TeacherName);
            Assert.Equal(dto.ChildCount, result.ChildCount);
        }

        [Fact]
        public async Task ShouldNot_CreateKindergarten_WhenFieldsNull()
        {
            KindergartenDto dto = MockKindergartenNullDto();

            var result = await Svc<IKindergartenServices>().Create(dto);

            Assert.NotNull(result);
            Assert.Null(dto.KindergartenName);
            Assert.Null(dto.GroupName);
            Assert.Null(dto.TeacherName);
        }

        [Fact]
        public async Task Should_GetKindergartenDetail_ById()
        {
            KindergartenDto dto = MockKindergartenDto();
            var created = await Svc<IKindergartenServices>().Create(dto);

            var result = await Svc<IKindergartenServices>().DetailAsync(created.Id);

            Assert.NotNull(result);
            Assert.Equal(created.Id, result.Id);
        }
        [Fact]
        public async Task Should_ReturnNull_WhenDetailIdDoesNotExist()
        {
            Guid wrongId = Guid.NewGuid();
            var result = await Svc<IKindergartenServices>().DetailAsync(wrongId);

            Assert.Null(result);
        }

        [Fact]
        public async Task Should_UpdateKindergarten_WhenDataChanged()
        {
            KindergartenDto dto = MockKindergartenDto();
            var createResult = await Svc<IKindergartenServices>().Create(dto);

            //var dtoId = dto.Id;
            //KindergartenDto domain = MockUpdateKindergartenData(dtoId);

            KindergartenDto domain = new()
            {
                Id = createResult.Id,
                KindergartenName = "Updated Kindergarten",
                GroupName = "Updated Group",
                TeacherName = "Updated Teacher",
                ChildCount = 25,
                CreatedAt = createResult.CreatedAt,
                UpdatedAt = DateTime.UtcNow
            };
            var updatedResult = await Svc<IKindergartenServices>().Update(domain);

            Assert.Equal(updatedResult.Id, createResult.Id);
            Assert.NotEqual(domain.KindergartenName, dto.KindergartenName);
            Assert.NotEqual(domain.TeacherName, dto.TeacherName);
            Assert.NotEqual(domain.GroupName, dto.GroupName);
            Assert.NotEqual(domain.ChildCount.ToString(), dto.ChildCount.ToString());
        }

        //[Fact]
        //public async Task Should_UpdateKindergarten_WhenDataChanged()
        //{
        //    //arrange
        //    var guid = new Guid("3d9967e6-5bf5-40dc-a517-0a481b931cbe");

        //    KindergartenDto dto = MockKindergartenDto();

        //    KindergartenDto domain = new();

        //    domain.Id = Guid.Parse("3d9967e6-5bf5-40dc-a517-0a481b931cbe");
        //    domain.KindergartenName = "Updated Kinder";
        //    domain.GroupName = "Updated Group";
        //    domain.TeacherName = "Updated Teacher";
        //    domain.ChildCount = 5;
        //    domain.CreatedAt = DateTime.UtcNow;
        //    domain.UpdatedAt = DateTime.UtcNow;

        //    //act
        //    await Svc<IKindergartenServices>().Update(dto);

        //    //assert
        //    Assert.Equal(domain.Id, guid);
        //    Assert.NotEqual(dto.KindergartenName, domain.KindergartenName);
        //    Assert.NotEqual(dto.GroupName, domain.GroupName);
        //    Assert.NotEqual(dto.TeacherName, domain.TeacherName);
        //    //Võrrelda RoomNumbrit ja kasutada DoesNotMatch
        //    Assert.DoesNotMatch(dto.ChildCount.ToString(), domain.ChildCount.ToString());
        //}

        [Fact]
        public async Task Should_DeleteKindergarten_WhenValidId()
        {
            KindergartenDto dto = MockKindergartenDto();
            var created = await Svc<IKindergartenServices>().Create(dto);

            var deleted = await Svc<IKindergartenServices>().Delete(created.Id);
            var afterDelete = await Svc<IKindergartenServices>().DetailAsync(created.Id);

            Assert.Equal(created.Id, deleted.Id);
            Assert.Null(afterDelete);
        }
        private KindergartenDto MockKindergartenDto()
        {
            return new KindergartenDto
            {
                KindergartenName = "Sunrise Kindergarten",
                GroupName = "Butterflies",
                TeacherName = "Mrs. Linda",
                ChildCount = 18,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }
        private KindergartenDto MockKindergartenNullDto()
        {
            return new KindergartenDto
            {
                KindergartenName = null,
                GroupName = null,
                TeacherName = null,
                ChildCount = null,
                CreatedAt = null,
                UpdatedAt = null
            };
        }
        private KindergartenDto MockKindergartenUpdateInitDto()
        {
            return new KindergartenDto
            {
                Id = Guid.NewGuid(),
                KindergartenName = "Sunrise Kindergarten",
                GroupName = "Butterflies",
                TeacherName = "Mrs. Linda",
                ChildCount = 18,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }
        private KindergartenDto MockUpdateKindergartenData(Guid? guid)
        {
            return new KindergartenDto
            {
                Id = guid,
                KindergartenName = "Updated Kindergarten",
                GroupName = "Updated Group",
                TeacherName = "Updated Teacher",
                ChildCount = 25,
                UpdatedAt = DateTime.UtcNow
            };
        }
    }
}
