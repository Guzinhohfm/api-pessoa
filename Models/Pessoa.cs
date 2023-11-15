using System.ComponentModel.DataAnnotations;

namespace api_pessoa.Models
{
    public class Pessoa
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage= "O nome da pessoa é um dado obrigatório")]
        public string nome { get; set; }

        [Required(ErrorMessage = "A data de nascimento da pessoa é um dado obrigatório")]
        public string dataNascimento { get; set; }

        [Required(ErrorMessage = "O sexo da pessoa é um dado obrigatório")]
        public string sexo { get; set; }

        [Required(ErrorMessage = "O cpf da pessoa é um dado obrigatório")]
        public string cpf { get; set; }

        [Required(ErrorMessage = "O logradouro da pessoa é um dado obrigatório")]
        public string logradouro { get; set; }

        [Required(ErrorMessage = "O bairro da pessoa é um dado obrigatório")]
        public string bairro { get; set; }

        [Required(ErrorMessage = "O número da residência da pessoa é um dado obrigatório")]
        public int numero { get; set; }

        [Required(ErrorMessage = "A cidade da pessoa é um dado obrigatório")]
        public string cidade { get; set; }

        [Required(ErrorMessage = "O estado da pessoa é um dado obrigatório")]
        public string estado { get; set; }



       
    }
}
