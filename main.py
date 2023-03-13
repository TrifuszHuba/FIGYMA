import os
import openai
import requests

f = open('test_options.txt', 'r')
input = f.read()
f.close()

openai.api_key = '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'
response = openai.Image.create(
    prompt=input,
    n=1,
    size="1024x1024"
)
image_url = response['data'][0]['url']

img_data = requests.get(image_url).content
with open('test.jpg', 'wb') as handler:
    handler.write(img_data)

print(image_url)

# a *tomeg*, *kivitel*, *modell*, *evjarat* *tipus* with *teto szin*
