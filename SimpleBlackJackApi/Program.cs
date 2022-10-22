using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseHttpsRedirection();
var cardTypes = new[]
{
    "Carreau", "Coeur", "Pique", "Trefle"
};
var cardValues = new[]
{
    "Roi", "Reine", "Valet", "10", "9", "8", "7", "6", "5", "4", "3", "2", "As"
};
app.MapGet("/getDeck", () => new Deck("2")).WithName("getDeck");
app.MapGet("/getCard{id}", (int deckId) => new Card
(
    cardTypes[new Random().Next(cardTypes.Length)],
    cardValues[new Random().Next(cardValues.Length)]
)).WithName("getCard");
app.Run();
internal record Deck(string id) { }
internal record Card(string rank, string suit) { }