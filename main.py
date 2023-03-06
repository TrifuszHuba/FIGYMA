import os
import openai

openai.api_key = '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'
response = openai.Image.create(
    prompt="a bald tall africa man",
    n=1,
    size="1024x1024"
)
image_url = response['data'][0]['url']

print(image_url)
