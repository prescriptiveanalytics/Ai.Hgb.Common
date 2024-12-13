﻿namespace Ai.Hgb.Common.Entities {
  public class RoutingTable : ICloneable {
    
    public List<Route> Routes;
    public List<Point> Points;

    //public List<Route> Routes {
    //  get { return routes; }
    //  private set { routes = value; }
    //}
    //public List<Point> Points {
    //  get { return points; }
    //  private set { points = value; }
    //}

    public RoutingTable() {
      Routes = new List<Route>();
      Points = new List<Point>();
    }

    public object Clone() {
      var t = new RoutingTable();
      t.Points.AddRange(Points.Select(x => (Point)x.Clone()));
      t.Routes.AddRange(Routes.Select(x => (Route)x.Clone()));

      return t;
    }

    public RoutingTable ExtractForPoint(string id) {
      var t = new RoutingTable();

      t.Routes.AddRange(Routes.Where(x => x.Source.Id == id || x.Sink.Id == id));
      Points.AddRange(t.Routes.Select(x => x.Source));
      Points.AddRange(t.Routes.Select(x => x.Sink));

      return t;
    }

    public void AddPoint(Point n) {
      Points.Add(n);
    }

    public void AddRoute(Route e) {
      Routes.Add(e);
    }

    public void RemovePoint(string id) {
      Routes.RemoveAll(x => x.Source.Id == id || x.Sink.Id == id);
      Points.RemoveAll(x => x.Id == id);
    }

    public void RemoveRoute(string id) {
      Routes.RemoveAll(x => x.Source.Id == id || x.Sink.Id == id);
    }
  }

  public class Route : ICloneable {

    public string Id { get; set; }
    public Point Source { get; set; }
    public Port SourcePort { get; set; }
    public Point Sink { get; set; }
    public Port SinkPort { get; set; }
    public string Query { get; set; }

    public Route() { }
    public Route(string id, Point source, Point sink, string query = null) {
      Id = id;
      Source = source;
      Sink = sink;
      Query = query;
    }
    public Route(string id, Point source, Port sourcePort, Point sink, Port sinkPort, string query = null) {
      Id = id;
      Source = source;
      SourcePort = sourcePort;
      Sink = sink;
      SinkPort = sinkPort;
      Query = query;
    }

    public object Clone() {
      return new Route(Id, Source, SourcePort, Sink, SinkPort, Query);
    }

    public string GetRoutingString(string delimiter) {
      return $"{Source.Typename}{delimiter}{Source.Id}";
    }
  }

  public class Point : ICloneable { // Location, Station, 
    public string Id { get; set; }

    public string Typename { get; set; }

    public string FullyQualifiedTypename { get; set; }

    public List<Port> Ports { get; set; }

    public Point() { }

    public Point(string id, string typename, string fullyQualifiedTypename, List<Port> ports) {
      Id = id;
      Typename = typename;
      FullyQualifiedTypename = fullyQualifiedTypename;
      Ports = ports;
    }

    public object Clone() {
      return new Point(Id, Typename, FullyQualifiedTypename, Ports);
    }

    public string GetRoutingString(string delimiter) {
      return $"{Typename}{delimiter}{Id}";
    }
  }

  public class Port {
    public string Id { get; set; }
    public PortType Type { get; set; }
    
    // will be generated by orchestrator
    // e.g. for a producer-consumer application with MQTT protocol: runId_XXX/pro/docs/
    // --> runId_XXX = generated, unique id
    // --> pro = name of the producer node
    // --> docs = name of producer node's port
    public string Address { get; set; }

    public Port() { }
  }

  public enum PortType {
    In,
    Out,
    Producer,
    Consumer,
    Client,
    Server
  }
}
