using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Application.Announcements.Commands.EditAnnouncement;

public class EditAnnouncementCommand : IRequest
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Pole 'Nazwa ogłoszenia' jest wymagane")]
    [Display(Name = "Nazwa ogłoszenia")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Pole 'Opis' jest wymagane")]
    [Display(Name = "Opis")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Pole 'Telefon' jest wymagane")]
    [Display(Name = "Telefon")]
    [Phone]
    public string PhoneNumber { get; set; }

    [Display(Name = "Ogłoszenie prywatne")]
    public bool IsPrivateAnnouncement { get; set; }

    [Required(ErrorMessage = "Pole 'Kraj' jest wymagane")]
    [Display(Name = "Kraj")]
    public string Country { get; set; }

    [Required(ErrorMessage = "Pole 'Miasto' jest wymagane")]
    [Display(Name = "Miasto")]
    public string City { get; set; }

    [Required(ErrorMessage = "Pole 'Ulica' jest wymagane")]
    [Display(Name = "Ulica")]
    public string Street { get; set; }

    [Required(ErrorMessage = "Pole 'Numer domu/mieszkania' jest wymagane")]
    [Display(Name = "Numer domu/mieszkania")]
    public string StreetNumber { get; set; }

    [Required(ErrorMessage = "Pole 'Kod pocztowy' jest wymagane")]
    [Display(Name = "Kod pocztowy")]
    public string ZipCode { get; set; }

    [Required(ErrorMessage = "Pole 'Cena' jest wymagane")]
    [Display(Name = "Cena")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Pole 'Powierzchnia' jest wymagane")]
    [Display(Name = "Powierzchnia")]
    public decimal Surface { get; set; }

    [Required(ErrorMessage = "Pole 'Liczba pokoi' jest wymagane")]
    [Display(Name = "Liczba pokoi")]
    public int NumberOfRooms { get; set; }

    [Required(ErrorMessage = "Pole 'Rok konstrukcjii' jest wymagane")]
    [Display(Name = "Rok konstrukcjii")]
    public int YearOfConstruction { get; set; }

    [Required(ErrorMessage = "Pole 'Rodzaj nieruchomości' jest wymagane")]
    [Display(Name = "Rodzaj nieruchomości")]
    public int RealEstateTypeId { get; set; }

    public IEnumerable<IFormFile> Files { get; set; }
}
