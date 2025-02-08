string[] jobs = new string[] { "Grocery Bagger", "Engineer", "Customer Service Representative" };

for (int i=0; i<3; i++)
{
    Console.WriteLine(jobs[i]);
}


int[] bowlingScores = new int[3];
bowlingScores[0] = 174; 
bowlingScores[1] = 188; 
bowlingScores[2] = 207;
int series = 0;
int averageScore = 0;
for (int i = 0; i<3; i++)
{
    series += bowlingScores[i];    
}
averageScore = series / bowlingScores.Length;
Console.WriteLine($"{bowlingScores[0]}+{bowlingScores[1]}+{bowlingScores[2]} = {series} Average: {averageScore}");



decimal[] prices = new decimal[] { 4.99m, 5.99m, 6.99m };
string[] foods = new string[] { "Blue Berries", "Cheese Sticks", "Texas Sausage" };
for (int i = 0; i < foods.Length; i++)
{
    Console.WriteLine($"The price of {foods[i]} is ${prices[i]:F2}");
}



// Collection expression
string[] dogs = ["Labrador", "Great Dane", "Poodle"];
decimal[] dogPrices = [74.99m, 95.99m, 0.10m];
for (int i = 0; i < dogs.Length; i++)
{
    Console.WriteLine($"The price of a {dogs[i]} is ${dogPrices[i]:F2}");
}


