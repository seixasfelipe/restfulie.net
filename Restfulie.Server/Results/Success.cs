﻿using System.Net;
using System.Linq;
using Restfulie.Server.Results.Decorators;

namespace Restfulie.Server.Results
{
    public class Success : RestfulieResult
    {
        public Success() { }
        public Success(object model) : base(model) { }

        public override ResultDecorator GetDecorators()
        {
            return new StatusCode((int)HttpStatusCode.OK,
                   new ContentType(MediaType.Synonyms.First(),
                   new Content(BuildContent())));
        }
    }
}