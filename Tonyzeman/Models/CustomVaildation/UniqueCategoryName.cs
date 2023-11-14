using Tonyzeman.Models.Context;
using System.ComponentModel.DataAnnotations;
using Tonyzeman.Repository;
using Tonyzeman.Repository.IReposatory;

namespace Tonyzeman.Models.CustomVaildation
{
    public class UniqueCategoryNameAttribute : ValidationAttribute
    {
        private readonly ICategory context;

        public UniqueCategoryNameAttribute(ICategory context)
        {
            this.context = context;
        }











        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {


            string uniqueName = (string)value;


            Category? categoryName = context.GetAll().FirstOrDefault(e => (e.Name == uniqueName));



            if (categoryName == null)
            {
                return ValidationResult.Success;
            }


            return new ValidationResult("Name is Already Taken");
        }
    }
}
