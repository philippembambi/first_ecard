using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace First.Ecard.Presentation.UI.Components.Models
{
    public class ClientRequest
    {
        [Required(ErrorMessage = "Veillez renseigner le Type de pièce d'identité")]
        public string IdCardType { get; set; } = string.Empty;

        [Required(ErrorMessage = "Veillez renseigner le Numéro de pièce d'identité")]
        public string IdCardNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Veillez renseigner le Prénom")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Veillez renseigner le Nom")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Veillez renseigner le Sexe")]
        public string Gender { get; set; } = string.Empty;

        [Required(ErrorMessage = "Veillez renseigner la date de naissance")]
        public DateOnly DateOfBirth { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);

        [Required(ErrorMessage = "Veillez renseigner la nationalité")]
        public string Nationality { get; set; } = string.Empty;

        [Required(ErrorMessage = "Veillez renseigner l'adresse")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Veillez renseigner le Numéro de téléphone")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Veillez renseigner l'adresse email")]
        public string Email { get; set; } = string.Empty;
    }
}