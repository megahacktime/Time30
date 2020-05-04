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
    - [Nat announced](https://twitter.com/natfriedman/status/1126544306712350721), that they working on improving the mobile experience, which is great news for everybody :)
- You can't use your own domain
- If you use your own domain, you have to use GitHub Pages (which is excellent btw), but then you have to have HTML files ready, which is exactly what this project solves.

## Solution

A simple script that converts a markdown (`.md`) file to a single HTML file, that includes all the HTML and CSS code inline, so you can host it anywhere.

There is no need to use this script if you already convert your markdown file to HTML, you can directly use the [stylesheet](https://github.com/KrauseFx/markdown-to-html-github-style/blob/master/style.css) of this repo.

## How it works

This project doesn't actually use the GitHub stylesheet, it's far too complex, and has legal implications.

Instead this project does 2 things:

<style type='text/css'>body {
  font: 400 16px/1.5 "Helvetica Neue", Helvetica, Arial, sans-serif;
  color: #111;
  background-color: #fdfdfd;
  -webkit-text-size-adjust: 100%;
  -webkit-font-feature-settings: "kern" 1;
  -moz-font-feature-settings: "kern" 1;
  -o-font-feature-settings: "kern" 1;
  font-feature-settings: "kern" 1;
  font-kerning: normal;
  padding: 30px;
}

@media only screen and (max-width: 600px) {
  body {
    padding: 5px;
  }

  body > #content {
    padding: 0px 20px 20px 20px !important;
  }
}

body > #content {
  margin: 0px;
  max-width: 900px;
  border: 1px solid #e1e4e8;
  padding: 10px 40px;
  padding-bottom: 20px;
  border-radius: 2px;
  margin-left: auto;
  margin-right: auto;
}

hr {
  color: #bbb;
  background-color: #bbb;
  height: 1px;
  flex: 0 1 auto;
  margin: 1em 0;
  padding: 0;
  border: none;
}

/**
 * Links
 */
a {
  color: #0366d6;
  text-decoration: none; }
  a:visited {
    color: #0366d6; }
  a:hover {
    color: #0366d6;
    text-decoration: underline; }

pre {
  background-color: #f6f8fa;
  border-radius: 3px;
  font-size: 85%;
  line-height: 1.45;
  overflow: auto;
  padding: 16px;
}

/**
  * Code blocks
  */

code {
  background-color: rgba(27,31,35,.05);
  border-radius: 3px;
  font-size: 85%;
  margin: 0;
  word-wrap: break-word;
  padding: .2em .4em;
  font-family: SFMono-Regular,Consolas,Liberation Mono,Menlo,Courier,monospace;
}

pre > code {
  background-color: transparent;
  border: 0;
  display: inline;
  line-height: inherit;
  margin: 0;
  overflow: visible;
  padding: 0;
  word-wrap: normal;
  font-size: 100%;
}


/**
 * Blockquotes
 */
blockquote {
  margin-left: 30px;
  margin-top: 0px;
  margin-bottom: 16px;
  border-left-width: 3px;
  padding: 0 1em;
  color: #828282;
  border-left: 4px solid #e8e8e8;
  padding-left: 15px;
  font-size: 18px;
  letter-spacing: -1px;
  font-style: italic;
}
blockquote * {
  font-style: normal !important;
  letter-spacing: 0;
  color: #6a737d !important;
}

/**
 * Tables
 */
table {
  border-spacing: 2px;
  display: block;
  font-size: 14px;
  overflow: auto;
  width: 100%;
  margin-bottom: 16px;
  border-spacing: 0;
  border-collapse: collapse;
}

td {
  padding: 6px 13px;
  border: 1px solid #dfe2e5;
}

th {
  font-weight: 600;
  padding: 6px 13px;
  border: 1px solid #dfe2e5;
}

tr {
  background-color: #fff;
  border-top: 1px solid #c6cbd1;
}

table tr:nth-child(2n) {
  background-color: #f6f8fa;
}

/**
 * Others
 */

img {
  max-width: 100%;
}

p {
  line-height: 24px;
  font-weight: 400;
  font-size: 16px;
  color: #24292e; }

ul {
  margin-top: 0; }

li {
  color: #24292e;
  font-size: 16px;
  font-weight: 400;
  line-height: 1.5; }

li + li {
  margin-top: 0.25em; }

* {
  font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Helvetica, Arial, sans-serif, "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol";
  color: #24292e; }

a:visited {
  color: #0366d6; }

h1, h2, h3 {
  border-bottom: 1px solid #eaecef;
  color: #111;
  /* Darker */ 
}</style>
