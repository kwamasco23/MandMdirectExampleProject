
pipeline {
    agent any

    tools {
        // Make sure you have a .NET SDK configured in Jenkins called 'dotnet8'
        dotnet 'dotnet8'
    }

    environment {
        // Add your Slack Workspace credentials ID in Jenkins → Credentials
        SLACK_CREDENTIALS = 'slack-token-id'
        SLACK_CHANNEL = '#general' // or your preferred channel
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
        always {
            slackSend(
                channel: env.SLACK_CHANNEL,
                color: '#439FE0',
                message: "Build #${env.BUILD_NUMBER} finished for ${env.JOB_NAME}. Check console output: ${env.BUILD_URL}",
                tokenCredentialId: env.SLACK_CREDENTIALS
            )
        }
        success {
            slackSend(
                channel: env.SLACK_CHANNEL,
                color: 'good',
                message: "✅ Build #${env.BUILD_NUMBER} succeeded for ${env.JOB_NAME}.",
                tokenCredentialId: env.SLACK_CREDENTIALS
            )
        }
        failure {
            slackSend(
                channel: env.SLACK_CHANNEL,
                color: 'danger',
                message: "❌ Build #${env.BUILD_NUMBER} failed for ${env.JOB_NAME}. Check logs: ${env.BUILD_URL}",
                tokenCredentialId: env.SLACK_CREDENTIALS
            )
        }
    }
}
