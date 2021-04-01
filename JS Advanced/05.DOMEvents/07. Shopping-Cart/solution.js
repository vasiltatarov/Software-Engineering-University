function solve() {
   const checkout = document.querySelector("textarea");

   const cart = [];

   document.querySelector('.shopping-cart').addEventListener('click', (ev) => {
      if (ev.target.tagName == 'BUTTON' && ev.target.className == 'add-product') {
         const product = ev.target.parentNode.parentNode;
         const title = product.querySelector('.product-title').textContent;
         const price = Number(product.querySelector('.product-line-price').textContent);

         cart.push({ title, price });

         checkout.textContent += `Added ${title} for ${price.toFixed(2)} to the cart.\n`;
      }
   });

   document.querySelector('.checkout').addEventListener('click', (ev) => {
      const result = cart.reduce((acc, curr) => {
         acc.items.add(curr.title);
         acc.total += curr.price;
         return acc;
      }, { items: new Set(), total: 0 });
      
      checkout.textContent += `You bought ${[...result.items].join(', ')} for ${result.total.toFixed(2)}.`;

      //disabled all buttons
      document.querySelectorAll('button').forEach(elem => {
         elem.disabled = true;
     });
   });
}