

string[] employeeNames = { "John", "Mary", "Sue", "Bob", "Alice" };

int[,] employees = {{ 4, 3, 4 }, { 3, 4, 5 }, { 3, 3, 3 }, { 5, 2, 1 }, { 3, 4, 4 }};

int employeeCount = 5;
int employee = 0;
int metricCount = 3;
int metric = 0;

double[] overallScores = { 0.0d, 0.0d, 0.0d, 0.0d, 0.0d };  //Averages of RAD, NAS, INV for 5 employees

do
{
    metric = 0;
    do
    {
        overallScores[employee] += employees[employee, metric];
        metric++;
    } while (metric < metricCount);

    overallScores[employee] /= metricCount;
    employee++;
} while (employee < employeeCount);

employee = 0;
do
{
    Console.WriteLine($"Employee: {employeeNames[employee]} has an overall score of: {overallScores[employee]:F2}");
    employee++;
} while (employee < employeeCount) ;







