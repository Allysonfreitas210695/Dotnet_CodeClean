using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; private set; }
        public ICollection<Product> Products { get; private set; } 

        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            ValidateDomain(name);
            this.Id = id;
            this.Name = name;
        }

        public void Update(string name) {
            ValidateDomain(name);
            this.Name = name;
        }

        private void ValidateDomain(string name){

            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters");

            this.Name = name;
        }
    }
}