using System.Text.Json.Serialization;

namespace APIToyKids.Domain;
public class Reserva
{
    public int ReservaId { get; set; }
    public DateTime DataReserva { get; set; }
    public string HoraReserva { get; set; }
    public int QuantidadePessoas { get; set; }
    public bool EspacoFesta { get; set; }
    public string? NomeEspacoFesta { get; set; }
    public int UsuarioId { get; set; }
    [JsonIgnore]
    public Usuario? Usuario { get; set;}
}
