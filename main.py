import os
import openai
import requests

openai.api_key = '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'
response = openai.Image.create(
    prompt="a bald tall africa man",
    n=1,
    size="1024x1024"
)
image_url = response['data'][0]['url']

img_data = requests.get(image_url).content
with open('test.jpg', 'wb') as handler:
    handler.write(img_data)
