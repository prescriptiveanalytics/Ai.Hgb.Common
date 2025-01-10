using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ai.Hgb.Common.Entities {
  public class ApplicationParametersBase {
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("description")]
    public string Description { get; set; }

    public ApplicationParametersBase() { }

    public ApplicationParametersBase(string name, string description) {
      Name = name;
      Description = description;
    }

    public override string ToString() {
      return $"{Name}";
    }
  }

  public class ApplicationParametersNetworking {
    [JsonPropertyName("hostName")]
    public string HostName { get; set; }
    [JsonPropertyName("hostPort")]
    public int HostPort { get; set; }

    public ApplicationParametersNetworking() { }

    public ApplicationParametersNetworking(string hostName, int hostPort) {
      HostName = hostName;
      HostPort = hostPort;
    }
  
    public override string ToString() {
      return $"{HostName}:{HostPort}";
    }
  }

  public interface IApplicationParametersBase {
    ApplicationParametersBase ApplicationParametersBase { get; set; }
  }

  public interface IApplicationParametersNetworking {
    ApplicationParametersNetworking ApplicationParametersNetworking { get; set; }
  }

  public class ApplicationParameters : ApplicationParametersBase {
    [JsonPropertyName("hostName")]
    public string HostName { get; set; }
    [JsonPropertyName("hostPort")]
    public int HostPort { get; set; }

    public ApplicationParameters(string name, string description, string hostName, int hostPort) {
      Name = name;
      Description = description;
      HostName = hostName;
      HostPort = hostPort;
    }

    public override string ToString() {
      return $"{Name}: {HostName}:{HostPort}";
    }
  }
}
