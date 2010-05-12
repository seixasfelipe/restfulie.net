﻿using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using Restfulie.Server.Exceptions;
using Restfulie.Server.Negotitation;
using Restfulie.Server.Results;

namespace Restfulie.Server.Tests
{
    [TestFixture]
    public class ActAsRestifulieTests
    {
        [Test]
        public void ShouldReturnNotAcceptableWhenMediaTypeIsNotSupported()
        {
            var context = new ActionExecutingContext();

            var factory = new Mock<IRepresentationFactory>();
            factory.Setup(f => f.BasedOnMediaType(It.IsAny<string>())).Throws(new MediaTypeNotSupportedException());

            var acceptHeader = new Mock<IAcceptHeaderFinder>();
            acceptHeader.Setup(ah => ah.FindIn(context)).Returns("some-crazy-media-type");

            var filter = new ActAsRestfulie(factory.Object, acceptHeader.Object);
            
            filter.OnActionExecuting(context);

            Assert.IsTrue(context.Result is NotAcceptable);
        }
    }
}
