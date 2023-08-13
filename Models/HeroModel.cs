using System;
namespace SuperHeroAPI.Models;

using System.ComponentModel.DataAnnotations;


public class HeroModel
{
	public int ID { get; set; }
	public required string Name { get; set; }
	public double rating { get; set; }
	public required string Description { get; set; }
}

