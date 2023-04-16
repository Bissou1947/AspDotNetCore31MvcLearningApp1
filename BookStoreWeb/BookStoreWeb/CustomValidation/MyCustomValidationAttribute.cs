using System.ComponentModel.DataAnnotations;

namespace BookStoreWeb.CustomValidation
{
    public class MyCustomValidationAttribute: ValidationAttribute
    {
        //....test on book title

        //...to make text must add from attribute
        public MyCustomValidationAttribute(string _text)
        {
            text = _text;
        }
        //...get name dynamic from attribute
        public string text { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                string bookTitle = value.ToString();
                if (bookTitle.ToLower().Contains(text))
                {
                    return ValidationResult.Success;
                }
            }
            //...if there errormessage from attribute or not
            return new ValidationResult(ErrorMessage ?? "title does not contain mvc/MVC");
        }
    }
}
