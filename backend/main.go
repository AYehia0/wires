package main

import "github.com/gin-gonic/gin"

var (
	SSL_CERT = "/etc/letsencrypt/live/api.ayehia0.info/fullchain.pem"
	SSL_KEY  = "/etc/letsencrypt/live/api.ayehia0.info/privkey.pem"
)

func main() {
	r := gin.Default()
	r.GET("/ping", func(c *gin.Context) {
		c.JSON(200, gin.H{
			"message": "Pong",
		})
	})

	// check if the server is running on production then enbale http
	if gin.Mode() == gin.ReleaseMode {
		r.RunTLS(":443", SSL_CERT, SSL_KEY)
	} else {
		r.Run(":8080")
	}
}
