using FluentValidation;
using RestAPI.Application.ViewModels.Products;


namespace RestAPI.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        private bool BeAValidCategory(string kategoriAdi)
        {
            return kategoriAdi == "Çorbalar" || kategoriAdi == "Ana Yemekler" || kategoriAdi == "Mezeler" || kategoriAdi == "Tatlılar" || kategoriAdi == "İçecekler" || kategoriAdi == "Ara Sıcaklar" || kategoriAdi == "Salatalar";
        }
        public CreateProductValidator()
        {
            RuleFor(p => p.Category)
               .NotEmpty()
               .NotNull()
                   .WithMessage("Lütfen kategori adını boş bırakmayınız.")
               .MaximumLength(150)
               .MinimumLength(1)
                   .WithMessage("Lütfen kategori adını 1 ile 150 karakter arasında giriniz.")
               .Must(BeAValidCategory).WithMessage("Kategori 'Çorbalar', 'Mezeler', 'Salatalar', 'Ara Sıcaklar', 'Ana Yemekler', 'Tatlılar', 'İçecekler' seçeneklerinden biri olmalıdır.");

            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen ürün adını boş bırakmayınız.")
                .MaximumLength(150)
                .MinimumLength(1)
                    .WithMessage("Lütfen ürün adını 1 ile 150 karakter arasında giriniz.");

            RuleFor(p => p.Stock)
               .NotEmpty()
               .NotNull()
                   .WithMessage("Lütfen stok bilgisini boş bırakmayınız.")
               .Must(s => s >= 0)
                   .WithMessage("Stok bilgisi negatif olamaz.");

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen fiyat bilgisini boş bırakmayınız.")
                .Must(r => r >= 0)
                    .WithMessage("Fiyat bilgisi negatif olamaz."); 
        }
    }
}
