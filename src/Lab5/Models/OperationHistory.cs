namespace Models;

public record OperationHistory(long Id, long UserId, Operation Operation, double Money);