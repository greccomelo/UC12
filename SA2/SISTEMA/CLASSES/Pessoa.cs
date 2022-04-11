using CADASTRO_PESSOA.Interfaces;

namespace CADASTRO_PESSOA.Classes
{
    public abstract class Pessoa : IPessoa
    {
            public string ?nome { get; set; }

            public string ?DatNasc { get; set; }
            
            public Endereco ?endereco { get; set; }

            public float rendimento { get; set; }
            
       
        public abstract float PagarImposto(float rendimento);
   
       }
}


