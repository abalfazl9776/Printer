using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Contracts;
using Entities.Customer.NaturalPerson;
using Microsoft.AspNetCore.Mvc;
using MyApi.Models;
using WebFramework.Api;
using WebFramework.Filters;

namespace MyApi.Controllers.v1
{
    [ApiVersion("1")]
    public class NaturalPersonController : CrudController<NaturalPersonDto, NaturalPersonDto, NaturalPerson>
    {
        public NaturalPersonController(IRepository<NaturalPerson> repository, IMapper mapper) 
            : base(repository, mapper)
        {
        }
    }
}
