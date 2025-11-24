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
            Assert.Null(result.KindergartenName);
            Assert.Null(result.GroupName);
            Assert.Null(result.TeacherName);
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
            var createDto = MockKindergartenDto();
            var created = await Svc<IKindergartenServices>().Create(createDto);

            KindergartenDto updateDto = MockUpdatedKindergartenData();
            updateDto.Id = created.Id;
            updateDto.CreatedAt = created.CreatedAt;

            var updated = await Svc<IKindergartenServices>().Update(updateDto);

            Assert.NotEqual(created.GroupName, updated.GroupName);
            Assert.NotEqual(created.ChildCount, updated.ChildCount);
            Assert.NotEqual(created.TeacherName, updated.TeacherName);
        }

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

        private KindergartenDto MockUpdatedKindergartenData()
        {
            return new KindergartenDto
            {
                KindergartenName = "Updated Kindergarten",
                GroupName = "Updated Group",
                TeacherName = "Updated Teacher",
                ChildCount = 25,
                UpdatedAt = DateTime.UtcNow
            };
        }
    }
}
