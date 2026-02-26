namespace StudentManagementMVC.Helpers;

public static class BackgroundLogger
{
    public static void LogStudentAdded(string studentName)
    {
        Thread t = new Thread(() =>
        {
            File.AppendAllText(
                "log.txt",$"Student Added: {studentName}{Environment.NewLine}"
            );
        });

        t.Start();
    }
}
