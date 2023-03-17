import os
import openai
import requests
import base64

f = open('test_options.txt', 'r')
input = f.read()
f.close()

openai.api_key = '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'
response = openai.Image.create(
    prompt=input,
    n=5,
    size="1024x1024",
    response_format="b64_json"
)
for i in range(5):
    image_json = response['data'][i]['b64_json']

    img_data = base64.urlsafe_b64decode(image_json)
    with open(f'img{i}.jpg', 'wb') as handler:
        handler.write(img_data)

# a *tomeg*, *kivitel*, *modell*, *evjarat* *tipus* with *teto szin*
