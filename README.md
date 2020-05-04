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
            <li>Maybe your project isn't actually an open source project, so you can't just host a <code>README</code> on GitHub</li>
            <li>If you want to link to just the <code>README</code>, you could append <code>#readme</code> to your browser URL (making the URL less pretty), or the visitor has to know they have to scroll down</li>
            <li>
                The mobile page of GitHub is still pretty bad, and it only renders the first few lines, as soon as you have a logo and badges on your page, it doesn't render at all, unless the visitor hits <code>View all of</code>README<code>.md</code><ul>
                    <li>Non-tech visitors don't know what's a <code>README.md</code></li>
                    <li>The button is small, and people don't know what is</li>
                    <li>GitHub renders the GitHub Pulse below, something that doens't make sense for non-tech visitors</li>
                    <li>The URL changes from something nice like <code>github.com/krausefx/fastlane</code> to <code>github.com/krausefx/fastlane/blob/master/README.md</code>, meaning you can either link directly to this page to have a nice content, or you link to the root page and have the downside of the extra buttons</li>
                    <li><a href="https://twitter.com/natfriedman/status/1126544306712350721">Nat announced</a>, that they working on improving the mobile experience, which is great news for everybody :)</li>
                </ul>
            </li>
            <li>You can't use your own domain</li>
            <li>If you use your own domain, you have to use GitHub Pages (which is excellent btw), but then you have to have HTML files ready, which is exactly what this project solves.</li>
        </ul>
        <h2 id="solution">Solution</h2>
        <p>A simple script that converts a markdown (<code>.md</code>) file to a single HTML file, that includes all the HTML and CSS code inline, so you can host it anywhere.</p>
        <p>There is no need to use this script if you already convert your markdown file to HTML, you can directly use the <a href="https://github.com/KrauseFx/markdown-to-html-github-style/blob/master/style.css">stylesheet</a> of this repo.</p>
        <h2 id="how-it-works">How it works</h2>
        <p>This project doesn't actually use the GitHub stylesheet, it's far too complex, and has legal implications.</p>
        <p>Instead this project does 2 things:</p>
        <ul>
            <li>Convert the Markdown to HTML using <a href="https://github.com/showdownjs/showdown">showdown</a>, the most popular JS markdown parser. This could be replaced by the <a href="https://github.com/KrauseFx/markdown-to-html-github-style/issues/2">official GitHub markdown to HTML API</a></li>
            <li>Inject the GitHub-like CSS code at the bottom of the page</li>
        </ul>
        <p>Resulting you get an HTML file that contains everything needed, so you can host the page on GitHub pages, AWS S3, Google Cloud Storage or anywhere else.</p>
        <ul>
            <li>Check out <a href="https://github.com/KrauseFx/markdown-to-html-github-style/blob/master/README.md?raw=1">the original markdown</a> file of this <code>README</code></li>
            <li>Check out the <a href="https://github.com/KrauseFx/markdown-to-html-github-style/blob/master/index.html">raw generated HTML code</a> generated based on this markdown file on</li>
            <li>Check out the <a href="https://github.com/KrauseFx/markdown-to-html-github-style">GitHub rendered README</a></li>
            <li>Check out the <a href="https://markdown-to-github-style-web.com">README rendered by this project</a></li>
        </ul>
        <h2 id="usage">Usage</h2>
<pre><code>node convert.js MyPageTitle
</code></pre>
        <p>This will read the <code>README.md</code> from your current working directory and output the resulting HTML as <code>README.html</code> to the same directory.</p>
        <h2 id="open-tasks">Open tasks</h2>
        <p>Check out the <a href="https://github.com/KrauseFx/markdown-to-html-github-style/issues">open issues</a>, in particular code blocks currently don't support syntax highlighting, however that's something that's rather easy to add. For a minimalistic stylesheet we could take the styles from <a href="https://github.com/KrauseFx/krausefx.com/blob/021186e228e183904af68ad8fc500c35107f00ae/assets/main.scss#L345-L438">krausefx.com css</a>.</p>
        <h2 id="playground-to-test">Playground to test</h2>
<pre><code>{
  testcode: 1
}
</code></pre>
        <ul>
            <li>Bullet list item 1</li>
            <li>
                Bullet list item 2<ul>
                    <li>Bullet list item 2.1</li>
                    <li>Bullet list item 2.2</li>
                </ul>
            </li>
        </ul>
        <hr />
        <ol>
            <li>Numbered list item 1</li>
            <li>Numbered list item 2</li>
        </ol>
        <p>Inline <code>code</code> comments are <code>100</code></p>
        <blockquote>
            <p>Quoted texts are more gray and look differently</p>
        </blockquote>
        <p><strong>Bold text</strong> is <strong>bold</strong> and <a href="https://krausefx.com">inline links</a> work as well.</p>
        <h1 id="header-1">Header 1</h1>
        <h2 id="header-2">Header 2</h2>
        <h3 id="header-3">Header 3</h3>
        <h4 id="header-4">Header 4</h4>
        <h5 id="header-5">Header 5</h5>
        <table>
            <tr>
                <td>
                    <img src="demo/screenshot1_framed.jpg">
                </td>
                <td>
                    <img src="demo/screenshot2_framed.jpg">
                </td>
                <td>
                    <img src="demo/screenshot3_framed.jpg">
                </td>
            </tr>
        </table>
        <p>Normal text content again, lorem ipsum</p>
        <table>
            <tr>
                <th>
                    Text 1
                </th>
                <th>
                    Text 2
                </th>
                <th>
                    Text 3
                </th>
            </tr>
            <tr>
                <td>
                    Text 1
                </td>
                <td>
                    Text 2
                </td>
                <td>
                    Text 3
                </td>
            </tr>
            <tr>
                <td>
                    Text 1
                </td>
                <td>
                    Text 2
                </td>
                <td>
                    Text 3
                </td>
            </tr>
        </table>
        <h3 style="text-align: center; font-size: 35px; border: none">
            <a href="https://t.me/WalkWithFriendsBot" target="_blank" style="text-decoration: none;">
                🔰 Raw HTML code for custom style 🔰
            </a>
        </h3>

    </div>
    <style type='text/css'>
               body {
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
                   text-decoration: none;
               }

                   a:visited {
                       color: #0366d6;
                   }

                   a:hover {
                       color: #0366d6;
                       text-decoration: underline;
                   }

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
                   color: #24292e;
               }

               ul {
                   margin-top: 0;
               }

               li {
                   color: #24292e;
                   font-size: 16px;
                   font-weight: 400;
                   line-height: 1.5;
               }

                   li + li {
                       margin-top: 0.25em;
                   }

               * {
                   font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Helvetica, Arial, sans-serif, "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol";
                   color: #24292e;
               }

               a:visited {
                   color: #0366d6;
               }

               h1, h2, h3 {
                   border-bottom: 1px solid #eaecef;
                   color: #111;
                   /* Darker */
               }
    </style>
</body>
</html>
