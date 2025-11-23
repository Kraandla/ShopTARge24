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
    }
}
