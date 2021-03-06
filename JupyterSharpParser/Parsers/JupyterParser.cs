﻿using System;
using JupyterSharpParser.Syntax;
using Markdig;
using Markdig.Syntax;
using Newtonsoft.Json;

namespace JupyterSharpParser.Parsers
{
    public class JupyterParser
    {
        private readonly MarkdownPipeline _markdownPipeline;
        private readonly string _text;

        /// <summary>
        /// Initializes a new instance of the <see cref="JupyterParser" /> class.
        /// </summary>
        /// <param name="text">The reader.</param
        /// <param name="pipeline">The pipeline.</param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public JupyterParser(string text, MarkdownPipeline pipeline)
        {
            _text = text;
            _markdownPipeline = pipeline;
        }

        /// <summary>
        /// Parses the specified Jupyter text into an <see cref="JupyterDocument"/>
        /// </summary>
        /// <param name="text">A Jupyter text</param>
        /// <param name="pipeline">The pipeline used for the parsing.</param>
        /// <returns>An Jupyter document</returns>
        /// <exception cref="ArgumentNullException">if reader variable is null</exception>
        public static JupyterDocument Parse(string text, MarkdownPipeline pipeline = null)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));
            pipeline = pipeline ?? new MarkdownPipelineBuilder().Build();

            // Perform the parsing
            var jupyterParser = new JupyterParser(text, pipeline);
            return jupyterParser.Parse();
        }

        /// <summary>
        /// Parses the current json text into a <see cref="JupyterDocument"/>.
        /// </summary>
        /// <returns>A document instance</returns>
        private JupyterDocument Parse()
        {
            //TODO : Add MarkdownPipeline
            return JsonConvert.DeserializeObject<JupyterDocument>(_text);
        }
    }
}