<html>
      <head>
        <title>markdown-to-html-github-style</title>
        <meta name="viewport" content="width=device-width, initial-scale=1">
      </head>
      <body>
        <div id='content'>
    <h1 id="markdown-to-github-style-web">Markdown to GitHub style web</h1>
<blockquote>
  <p>Because GitHub's <code>README</code> styling is actually really nice</p>
</blockquote>
<h2 id="background">Background</h2>
<p><a href="https://twitter.com/KrauseFx"><img src="https://img.shields.io/badge/author-@KrauseFx-blue.svg?style=flat" alt="" /></a></p>
<p>If you have a little side project, often you might want a simple landing page. The GitHub <code>README</code> rendering is really beautifully done: clean, simple and modern. The official <a href="https://developer.github.com/v3/markdown/">GitHub markdown to HTML API</a> generates the HTML code, but not the stylesheets necessary to make it look nice.</p>
<p>Using your GitHub <code>README</code> as the main landing point works great for open source projects, where your visitors are developers and are familiar with GitHub, as well as you have all the text right where the code, the Issues and PRs are. But for some projects this isn't ideal. I built this project within a few hours for myself to get <a href="https://walkwithfriends.net/">WalkWithFriends</a> off the ground fast, without investing in building an actual website, or using a bloated website builder.</p>
<p>Some issues you run into when using GitHub as your main landing page</p>
<ul>
</div>
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
  /* Darker */ }</style>
      </body>
    </html>
