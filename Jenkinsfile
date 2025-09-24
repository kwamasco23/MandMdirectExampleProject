
pipeline {
    agent any

    environment {
        SLACK_TOKEN = credentials('slack-token-id') // Jenkins secret ID for Slack token
        SLACK_CHANNEL = '#general'                  // Slack channel
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
        success {
            slackSend(
                channel: "${env.SLACK_CHANNEL}",
                color: 'good',
                message: "Build Succeeded: ${env.JOB_NAME} #${env.BUILD_NUMBER} (<${env.BUILD_URL}|Open>)",
                tokenCredentialId: 'slack-token-id'
            )
        }
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
