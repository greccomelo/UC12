using CADASTRO_PESSOA.Interfaces;

namespace CADASTRO_PESSOA.Classes
{
    public class PessoaFisica : Pessoa, IPessoaFisica
    {
        public string? cpf { get; set; }
        public string? dataNascimento { get; set; }


        public override float PagarImposto(float rendimento)
        {
            if (rendimento <= 1500)
            {
                return 0;
            }
            else if (rendimento > 1500 && rendimento <= 3500)
            {
                return (rendimento / 100) * 2;
            }
            else if (rendimento > 3500 && rendimento < 6000)
            {
                return (rendimento / 100) * 3.5f;
            }
            else
            {
                return (rendimento / 100) * 5;
            }
        }

        public bool ValidarDataNascimento(string dataNasc)
        {
            DateTime dataConvertida;
            if (DateTime.TryParse(dataNasc, out dataConvertida))
            {
                
            Console.WriteLine($"{dataConvertida}");
            
            
            DateTime dataAtual = DateTime.Today;

            double anos = (dataAtual - dataConvertida).TotalDays / 365;

            if (anos >= 18)
            {
                return true;
            }
                
            return false; 

            }
            return false;
       }

               public bool ValidarDataNascimento(DateTime dataNasc)
        {
            DateTime dataAtual = DateTime.Today;

           double anos = (dataAtual - dataNasc).TotalDays / 365;


            if (anos >= 18)
            {
                return true;
            }
                
            return false; 

            }
       }



    }

