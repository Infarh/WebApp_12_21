using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewModels;

public class ProductViewModel
{
    [HiddenInput(DisplayValue = false)]
    public int Id { get; set; }

    [Display(Name = "Название")]
    [StringLength(255, MinimumLength = 5, ErrorMessage = "Длина имени должна быть от 5 до 255 символов")]
    [RegularExpression("Product-\\d+")]
    //[DataType(DataType.Password)]
    public string Name { get; set; }

    [Display(Name = "Цена")]
    [Range(0, double.PositiveInfinity)]
    public decimal Price { get; set; }
}