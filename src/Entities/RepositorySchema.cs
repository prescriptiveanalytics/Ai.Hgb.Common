using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ai.Hgb.Common.Entities {
  public class Image {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }
    public string? Hash { get; set; }
    public string Name { get; set; }
    public string Tag { get; set; }
    public DateTime? Created { get; set; }
    public double? Size { get; set; }

    public List<Container> Containers { get; } = new();
    public Description? Description { get; set; }

    public Image() { }

    public Image(string id, string hash, string name, string tag, DateTime created, double size) {
      Id = id;
      Hash = hash;
      Name = name;
      Tag = tag;
      Created = created;
      Size = size;
    }
  }

  public class Container {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }
    public string? Hash { get; set; }
    public string Name { get; set; }
    public string? Status { get; set; }
    public DateTime? LastStarted { get; set; }
    public List<string> Ports { get; set; } = new();

    public Image? Image { get; set; }
    public Description? Description { get; set; }

    public Container() { }

    public Container(string id, string hash, string name, string status, DateTime lastStarted, List<string> ports, Image image = null) {
      Id = id;
      Hash = hash;
      Name = name;
      Status = status;
      LastStarted = lastStarted;
      Ports = ports;
      Image = image;
    }
  }

  public class Description {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }
    public string Name { get; set; }
    public string Tag { get; set; }
    public string? Text { get; set; }

    // reference properties
    public string? ImageId { get; set; }
    public string? ImageHash { get; set; }
    public string? ImageName { get; set; }
    public string? ImageTag { get; set; }
    //public Image Image { get; set; } = null!;

    public string? ContainerId { get; set; }
    public string? ContainerHash { get; set; }
    public string? ContainerName { get; set; }


    public Description() { }

    public Description(string id, string name, string tag, string text) {
      Id = id;
      Name = name;
      Tag = tag;
      Text = text;
    }
  }

  public class Package {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }
    public string Name { get; set; }
    public string Tag { get; set; }
    public List<Description> Descriptions { get; set; } = new();

    public Package() { }
    public Package(string id, string name, string tag) {
      Id = id;
      Name = name;
      Tag = tag;
    }
  }
}