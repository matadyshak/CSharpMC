// This illustrates the memory reallocation that is needed with standard
// arrays to increase their size
// Lists have an Add() method which takes care of the reallocation "under the hood"

int[] testScores = { 100, 95, 90, 85, 70 };

Console.WriteLine("Print the original array of 5 elements...");
for (int j = 0; j<testScores.Length; j++)
{
    Console.WriteLine($"TestScore: {testScores[j]}");
}
Console.WriteLine("");

// Need to add more to the array
int[] testScores2 = new int[10];

for (int j = 0; j<testScores.Length; j++)
{
    //Copy the original array to the new larger array
    testScores2[j] = testScores[j];
}

//Initialize the new array with more test scores
int i = testScores.Length;
testScores2[i++] = 65;
testScores2[i++] = 60;
testScores2[i++] = 55;
testScores2[i++] = 50;
testScores2[i++] = 45;

// Print the new larger array
Console.WriteLine("Print the expanded array of 10 elements...");
for (int j = 0; j<testScores2.Length; j++)
{
    Console.WriteLine($"TestScore: {testScores2[j]}");
}
