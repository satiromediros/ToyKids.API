using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace APIToyKids.Domain;
public class Usuario
{
    public Usuario()
    {
        Reservas = new Collection<Reserva>();
    }
    public int UsuarioId { get; set; }
    [Required]
    [StringLength(50)]
    public string? Nome { get; set; }
    [Required]
    [MaxLength(11)]
    public string? CPF { get; set; }
    [EmailAddress]
    [Required]
    public string? Email { get; set; }
    [Required]
    [MaxLength(30)]
    public string? Senha { get; set; }
    public ICollection<Reserva>? Reservas { get; set; }
}
