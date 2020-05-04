# MEGAHACK 2.0

> Muito prazer somos o time 30 - desafio Globo.<br/>
Cauê Buck, Fernando Ferreira, Jorge Eugenio, Pedro F. Oliveira e Victor Baptista. 

## Desafio

Muitos serviços, muito conteúdo, mas como organizar a entrega e facilitar o acesso?

## Solução

<ol>
    <li>Human centered design</li>
</ol>

<bold>Com uma abordagem</bold> centrada no usuário procuramos verdadeiramente entender quais as maiores necessidades e dificuldades.
Diversidade canais
Em nossa pesquisa percebemos que a quantidade de aplicativos era algo prejudicial
Apenas informações importantes Apesar de nossa amostragem não ser tão abrangente, foi apontado por muitos entrevistados que a quantidade de informação apresentada muitas vezes os confundem.


If you have a little side project, often you might want a simple landing page. The GitHub `README` rendering is really beautifully done: clean, simple and modern. The official [GitHub markdown to HTML API](https://developer.github.com/v3/markdown/) generates the HTML code, but not the stylesheets necessary to make it look nice.

Using your GitHub `README` as the main landing point works great for open source projects, where your visitors are developers and are familiar with GitHub, as well as you have all the text right where the code, the Issues and PRs are. But for some projects this isn't ideal. I built this project within a few hours for myself to get [WalkWithFriends](https://walkwithfriends.net/) off the ground fast, without investing in building an actual website, or using a bloated website builder.

Some issues you run into when using GitHub as your main landing page

- Maybe your project isn't actually an open source project, so you can't just host a `README` on GitHub
- If you want to link to just the `README`, you could append `#readme` to your browser URL (making the URL less pretty), or the visitor has to know they have to scroll down
- The mobile page of GitHub is still pretty bad, and it only renders the first few lines, as soon as you have a logo and badges on your page, it doesn't render at all, unless the visitor hits `View all of `README`.md`
    - Non-tech visitors don't know what's a `README.md`
    - The button is small, and people don't know what is
    - GitHub renders the GitHub Pulse below, something that doens't make sense for non-tech visitors
    - The URL changes from something nice like `github.com/krausefx/fastlane` to `github.com/krausefx/fastlane/blob/master/README.md`, meaning you can either link directly to this page to have a nice content, or you link to the root page and have the downside of the extra buttons
