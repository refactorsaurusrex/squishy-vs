# SquishyVS

**Turn this...**

![Before squishyVS](https://raw.githubusercontent.com/refactorsaurusrex/squishy-vs/master/Images/BeforeSquishy.png)

**...into this:**

![After squishyVS](https://raw.githubusercontent.com/refactorsaurusrex/squishy-vs/master/Images/AfterSquishy.png)

**Now, isn't that nicer?**

# Installation
1. Download the `vsix` file from the [releases page](https://github.com/refactorsaurusrex/squishy-vs/releases).
2. Run it.
3. Profit!

This extension is *not* yet listed in the Visual Studio Gallery. I'll do that soon.

# Compatibility
Lest there be any doubt, this extension only works with Visual Studio 2015. 

# What's 'Squishy' about it?
It *squuuuuuishes* the display text down to a more palatable, bite-sited chunk! Yummy!

# The Hack
If you look at [how I implemented this extension](https://github.com/refactorsaurusrex/squishy-vs/blob/master/SquishyVS/TextViewCreationListener.cs#L35-L36), you'll notice I resorted to a fairly brutish hack: using reflection to forcibly set the backing field for the string property containing the display text for collapsed xml comments. It's not an ideal solution. That said, figuring out how to revert this behavior back to how it was in VS 2013 has already taken more time than I wanted to spend, so for now, this is **Good Enough&trade;**. However, if you have a better solution, I'm all ears! Open an issue, create a PR, [send me an email](http://refactorsaurusrex.com/contact-me/), whatever. I'd really love to know how to do this correctly, but, you know, time. :)
