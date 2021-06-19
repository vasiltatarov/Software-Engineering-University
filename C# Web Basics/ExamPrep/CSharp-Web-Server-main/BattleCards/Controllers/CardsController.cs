using System.Linq;
using BattleCards.Services;
using BattleCards.ViewModels.Cards;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
        private readonly ICardService cardService;
        private readonly IValidator validator;

        public CardsController(ICardService cardService, IValidator validator)
        {
            this.cardService = cardService;
            this.validator = validator;
        }

        public HttpResponse All()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Unauthorized();
            }

            var viewModel = this.cardService.All();

            return this.View(viewModel);
        }

        public HttpResponse Collection()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Unauthorized();
            }

            var userId = this.User.Id;
            var viewModel = this.cardService.MyCollection(userId);

            return this.View(viewModel);
        }

        public HttpResponse Add()
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Unauthorized();
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(CardInputModel model)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Unauthorized();
            }

            var errors = this.validator.ValidateCard(model);
            if (errors.Any())
            {
                return this.Error(errors);
            }

            this.cardService
                .Add(model.Name, model.Keyword, model.Image, model.Attack, model.Health, model.Description);

            return this.Redirect("/");
        }

        public HttpResponse AddToCollection(int cardId)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Unauthorized();
            }

            var userId = this.User.Id;
            this.cardService.AddToCollection(cardId, userId);

            return this.Redirect("/");
        }

        public HttpResponse RemoveFromCollection(int cardId)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Unauthorized();
            }

            var userId = this.User.Id;
            this.cardService.RemoveFromCollection(cardId, userId);

            return this.Redirect("/Cards/Collection");
        }
    }
}
