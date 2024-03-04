using api.Dtos.GiftCards;
using api.Models;

namespace api.Mappers
{
    public static class GiftCardMappers
    {
        public static async Task<GiftCard> ToGiftCardFromCreateGiftCardDto(this CreateGiftCardDto createGiftCardDto)
        {
            byte[]? fileContent = null;
            using (var memoryStream = new MemoryStream())
            {
                if (createGiftCardDto.File is not null)
                {
                    await createGiftCardDto.File.CopyToAsync(memoryStream);
                    fileContent = memoryStream.ToArray();
                }
            }

            return new GiftCard
            {
                Code = createGiftCardDto.Code,
                Description = createGiftCardDto.Description,
                Balance = createGiftCardDto.Balance,
                CloseDate = createGiftCardDto.CloseDate,
                OpenDate = createGiftCardDto.OpenDate,
                UserId = createGiftCardDto.UserId,
                Attachment = fileContent,
                CardNumber = createGiftCardDto.CardNumber,
                IsVoucher = createGiftCardDto.IsVoucher,
            };
        }

        public static GiftCardDto ToGiftCardDtoFromGiftCard(this GiftCard giftCard)
        {
            return new GiftCardDto
            {
                Balance = giftCard.Balance,
                CardNumber = giftCard.CardNumber,
                CloseDate = giftCard.CloseDate,
                Code = giftCard.Code,
                Description = giftCard.Description,
                IsVoucher = giftCard.IsVoucher,
                OpenDate = giftCard.OpenDate,
                UserId = giftCard.UserId,
            };
        }

        public static async Task<GiftCard> ToGiftCardFromUpdateGiftCardDto(this UpdateGiftCardDto updateGiftCardDto)
        {
            byte[]? fileContent = null;
            using (var memoryStream = new MemoryStream())
            {
                if (updateGiftCardDto.File is not null)
                {
                    await updateGiftCardDto.File.CopyToAsync(memoryStream);
                    fileContent = memoryStream.ToArray();
                }
            }

            return new GiftCard
            {
                Code = updateGiftCardDto.Code,
                Description = updateGiftCardDto.Description,
                Balance = updateGiftCardDto.Balance,
                CloseDate = updateGiftCardDto.CloseDate,
                OpenDate = updateGiftCardDto.OpenDate,
                UserId = updateGiftCardDto.UserId,
                Attachment = fileContent,
                CardNumber = updateGiftCardDto.CardNumber,
                IsVoucher = updateGiftCardDto.IsVoucher,
            };
        }

    }
}