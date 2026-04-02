namespace una_sdm_lista_09.Models
{
    public class Candidato
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string ViceNome { get; set; } = string.Empty;
        public int Numero { get; set; }
        public string Partido { get; set; } = string.Empty;
    }
}