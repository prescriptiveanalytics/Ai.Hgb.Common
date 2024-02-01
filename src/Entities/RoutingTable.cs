namespace Ai.Hgb.Common.Entities {
  public class RoutingTable : ICloneable {

    private List<Edge> edges;
    private List<Node> nodes;

    public List<Edge> Edges {
      get { return edges; }
      private set { edges = value; }
    }
    public List<Node> Nodes {
      get { return nodes; }
      private set { nodes = value; }
    }

    public RoutingTable() {
      edges = new List<Edge>();
      nodes = new List<Node>();
    }

    public object Clone() {
      var t = new RoutingTable();
      t.nodes.AddRange(nodes.Select(x => (Node)x.Clone()));
      t.edges.AddRange(edges.Select(x => (Edge)x.Clone()));

      return t;
    }

    public RoutingTable ExtractForNode(string id) {
      var t = new RoutingTable();

      t.edges.AddRange(edges.Where(x => x.Source.Id == id || x.Sink.Id == id));
      nodes.AddRange(t.edges.Select(x => x.Source));
      nodes.AddRange(t.edges.Select(x => x.Sink));

      return t;
    }

    public void AddNode(Node n) {
      nodes.Add(n);
    }

    public void AddEdge(Edge e) {
      edges.Add(e);
    }

    public void RemoveNode(string id) {
      edges.RemoveAll(x => x.Source.Id == id || x.Sink.Id == id);
      nodes.RemoveAll(x => x.Id == id);
    }

    public void RemoveEdge(string id) {
      edges.RemoveAll(x => x.Source.Id == id || x.Sink.Id == id);
    }
  }

  public class Edge : ICloneable {

    public string Id { get; set; }
    public Node Source { get; set; }
    public Node Sink { get; set; }
    public string Query { get; set; }

    public Edge() { }
    public Edge(string id, Node source, Node sink, string query = null) {
      Id = id;
      Source = source;
      Sink = sink;
      Query = query;
    }

    // TODO: add ports

    public object Clone() {
      return new Edge(Id, Source, Sink, Query);
    }

    public string GetRoutingString(string delimiter) {
      return $"{Source.Typename}{delimiter}{Source.Id}";
    }
  }

  public class Node : ICloneable {
    public string Id { get; set; }

    public string Typename { get; set; }

    public string FullyQualifiedTypename { get; set; }

    public List<Port> Ports { get; set; }

    public Node() { }

    public Node(string id, string typename, string fullyQualifiedTypename, List<Port> ports) {
      Id = id;
      Typename = typename;
      FullyQualifiedTypename = fullyQualifiedTypename;
      Ports = ports;
    }

    public object Clone() {
      return new Node(Id, Typename, FullyQualifiedTypename, Ports);
    }

    public string GetRoutingString(string delimiter) {
      return $"{Typename}{delimiter}{Id}";
    }
  }

  public struct Port {
    public string Id { get; set; }
    public string Type { get; set; } // in/out

    public Port() { }
  }
}
