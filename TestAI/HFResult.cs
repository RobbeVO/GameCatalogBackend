namespace TestAI;

public record HFResult(string sequence, IList<string> labels, IList<float> scores);