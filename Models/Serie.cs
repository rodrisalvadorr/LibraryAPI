using LibraryAPI.Models;

namespace LibraryAPI.Models
{
  public class Serie
  {
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public byte[]? Foto { get; set; }
    public int NroVolumes { get; set; }
  }
}