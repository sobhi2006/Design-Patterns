public class Program
{
    public static void Main(string[] args)
    {
        IAuditLogger auditLogger = new AuditLogger();
        
        auditLogger.Log(OperationType.Create, "UserService", LevelType.Info, 101, "User created successfully.");
        
        Console.WriteLine(auditLogger.GetTotalFlyweights());  // should be 1
        
        auditLogger.Log(OperationType.Update, "OrderService", LevelType.Warning, 102, "Order update took longer than expected.");
        
        Console.WriteLine(auditLogger.GetTotalFlyweights());  // should be 2
        
        auditLogger.Log(OperationType.Delete, "ProductService", LevelType.Error, 103, "Product deletion failed due to foreign key constraint.");
        auditLogger.Log(OperationType.Delete, "ProductService", LevelType.Error, 103, "Product deletion because it ended.");
        
        Console.WriteLine(auditLogger.GetTotalFlyweights());  // should be 3
        
        auditLogger.Log(OperationType.Read, "InventoryService", LevelType.Info, 104, "Inventory read operation completed.");
    }
}
