namespace CADASTRO_PESSOA.Interfaces
{
    public interface IPessoaFisica
    {
        float PagarImposto(float rendimento);
        bool ValidarDataNascimento(DateTime dataNasc);
    }
}