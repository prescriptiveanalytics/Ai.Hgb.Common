using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ai.Hgb.Common.Entities {

  // TODO: https://ms.codes/blogs/computer-hardware/c-get-cpu-usage-of-process#:~:text=Process%20%2D%20Key%20Takeaways-,To%20get%20the%20CPU%20usage%20of%20a%20process%20in%20C%23,processor%20time%20for%20the%20process.
  public class Heartbeat {
    public string Id { get; set; }
    public DateTime Timestamp { get; set; }
    public string ApplicationId { get; set; }
    public string ApplicationName { get; set;}
    public int CpuUtilization { get; set; }
    public int MemoryUtilization { get; set; }
    public int GpuUtilization { get; set; }

    public Heartbeat() { }

    public override string ToString() {
      return $"{Timestamp}:\t{CpuUtilization}\t{MemoryUtilization}\t{GpuUtilization}";
    }
  }

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
