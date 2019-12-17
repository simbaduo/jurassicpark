using System;

namespace jurassicpark
{
  // D I N O S A U R you are a dinosaur class
  public class Dinosaur
  {
    public string Name { get; set; }
    public int ID { get; set; }
    public string Type { get; set; }
    public string Diet { get; set; }
    public DateTime DateAdded { get; set; }
    public decimal Weight { get; set; } = 0;
    public int EnclosureNo { get; set; } = 0;

  }
}