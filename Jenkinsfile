
pipeline {
    agent any

    environment {
        SLACK_TOKEN = credentials('slack-token-id') 
        SLACK_CHANNEL = '#all-devopspractice'                
    }

    stages {
        stage('Checkout') {
            steps {
                git branch: 'main', url: 'https://github.com/kwamasco23/MandMdirectExampleProject.git'
            }
        }

        stage('Restore') {
            steps {
                bat 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet build --configuration Release --no-restore'
            }
        }

        stage('Test') {
            steps {
                bat 'dotnet test --no-build --verbosity normal'
            }
        }
    }

    post {
        failure {
            slackSend(
                channel: "${env.SLACK_CHANNEL}",
                color: 'danger',
                message: "Build Failed: ${env.JOB_NAME} #${env.BUILD_NUMBER} (<${env.BUILD_URL}|Open>)",
                tokenCredentialId: 'slack-token-id'
            )
        }
    }
}
