﻿using System.Linq;
using System.Reflection;

using Aliencube.AzureFunctions.Extensions.OpenApi.Attributes;
using Aliencube.AzureFunctions.Extensions.OpenApi.Enums;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aliencube.AzureFunctions.Extensions.OpenApi.Tests.Enums
{
    [TestClass]
    public class OpenApiVisibilityTypeTests
    {
        [TestMethod]
        public void Given_Enum_Should_Have_Member()
        {
            var members = typeof(OpenApiVisibilityType).GetMembers().Select(p => p.Name);

            members.Should().Contain("Undefined");
            members.Should().Contain("Important");
            members.Should().Contain("Advanced");
            members.Should().Contain("Internal");
        }

        [TestMethod]
        public void Given_Enum_Should_NotHave_Decorator()
        {
            var member = typeof(OpenApiVisibilityType).GetMember("Undefined").First();
            var attribute = member.GetCustomAttribute<DisplayAttribute>(inherit: false);

            attribute.Should().BeNull();
        }

        [TestMethod]
        public void Given_Enum_Should_Have_Decorator()
        {
            var member = this.GetMemberInfo("Important");
            var attribute = member.GetCustomAttribute<DisplayAttribute>(inherit: false);

            attribute.Should().NotBeNull();

            member = this.GetMemberInfo("Advanced");
            attribute = member.GetCustomAttribute<DisplayAttribute>(inherit: false);

            attribute.Should().NotBeNull();

            member = this.GetMemberInfo("Internal");
            attribute = member.GetCustomAttribute<DisplayAttribute>(inherit: false);

            attribute.Should().NotBeNull();
        }

        private MemberInfo GetMemberInfo(string name)
        {
            var member = typeof(OpenApiVisibilityType).GetMember(name).First();

            return member;
        }
    }
}
