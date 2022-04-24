import pandas as pd
import twitter
from vaderSentiment.vaderSentiment import SentimentIntensityAnalyzer
analyzer = SentimentIntensityAnalyzer()

api = twitter.Api(consumer_key="",
                  consumer_secret="",
                  access_token_key="",
                  access_token_secret="")

count = 20
query = "vaccine"
tweets = api.GetSearch(raw_query=query, count=count,
                       lang='en')

tweetsWithSent = []
for t in tweets['statuses']:
    text = (t['full_text'])
    ps = analyzer.polarity_scores(text)
    tweetsWithSent.append({'text': text, 'compound': ps['compound']})

tweetdf = pd.DataFrame(tweetsWithSent)
tweetdf.plot.bar(figsize=(15, 5), width=1)
