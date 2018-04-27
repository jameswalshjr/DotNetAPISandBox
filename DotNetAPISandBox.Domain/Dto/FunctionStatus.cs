using AutoMapper;
using DotNetAPISandBox.Domain.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetAPISandBox.Domain.Dto
{
    public class FunctionStatus
    {
        [Key]
        public Guid FunctionStatusId { get; set; }
        public string FunctionName { get; set; }
        public string FunctionDescription { get; set; }
        public bool EnableFunction { get; set; }

        public static explicit operator FunctionStatus(FunctionStatusEntity entity)
        {
            return Mapper.Map<FunctionStatus>(entity);
        }

        public static explicit operator FunctionStatusEntity(FunctionStatus dto)
        {
            return Mapper.Map<FunctionStatusEntity>(dto);
        }
    }
}
