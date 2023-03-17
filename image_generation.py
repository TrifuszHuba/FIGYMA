import os
import openai
import requests
import base64

file = open('test_options.txt', 'r')
input = file.read()
file.close()


try:
    api_key = open("api_key.txt", "r", encoding="utf-8").read()
    openai.api_key = api_key
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

except openai.error.AuthenticationError:
    print("Incorrect API key provided.")

except:
    print("Unknown error has occured.")
